<template>
  <div class="modal-body p-0 elevation-5">
    <div class="row rounded-5">

      <div class="col-md-6 pic rounded-start" :style="{ backgroundImage: `url(${keep.img})` }">
        <!-- <img :src="keep.img" alt="" class="img-fluid rounded-start h-100 piccy"> -->
      </div>



      <div class="col-md-6 d-flex flex-column justify-content-between ">
        <button class="btn btn-danger" @click="removeVaultKeep(keep?.vaultKeepId)"></button>
        <div class="">
          <div class="text-center mt-4 ">
            <img alt="logo" src="src\assets\img\Vector (2).png"> {{ keep.views }}
            <img alt="logo" src="src\assets\img\Logo.png"> {{ keep.kept }}
          </div>
          
      


        </div>




        <div class="">
          <h4 class="text-center keep-name">
            {{ keep.name }}
          </h4>
          <p class="p-4">
            {{ keep.description }}
          </p>
        </div>
        <div class="d-flex justify-content-end justify-content-between">
          <!-- <AddKeepToVault/> -->

          <form @submit.prevent="addToVault()">
            <div class="d-flex">
              <select class="form-select " v-model="editable">
                <option v-for="v in vaults" :value="v"><a class="dropdown-item" placeholder="Add to Vault">
                    {{ v?.name }}
                  </a></option>
              </select>
              <button class="btn save border-0" type="submit">save</button>
            </div>
          </form>







          <div class="d-flex me-3 mb-1">
            <router-link :to="{ name: 'Profile', params: { id: keep.creator.id } }">
              <img :src="keep.creator.picture" alt="" class="rounded-circle mx-2 mb-2" height="40" width="40"
                data-bs-dismiss="modal">
            </router-link>
            <p class="name">{{ keep.creator.name }}</p>
          </div>


        </div>
      </div>
    </div>
  </div>

  <!-- <div class="btn-group dropup">
  <button type="button" class="btn btn-secondary dropdown-toggle" data-bs-toggle="dropdown" aria-expanded="false">
    {{v?.name}}
  </button>
  <ul class="dropdown-menu" v-for="v in vaults" :value="v">

  </ul>
</div>
 -->

</template>


<script>

import { computed } from "@vue/reactivity";
import { RouterLink, useRoute } from "vue-router";
import { AppState } from "../AppState.js";
import { Keep } from "../models/Keep.js";
import AddKeepToVault from "./AddKeepToVault.vue";
import { ref } from "vue"
import Pop from "../utils/Pop.js";
import { vaultsService } from "../services/VaultsService.js";

export default {
  props: {
    keep: {
      type: Keep,
      required: true
    }
  },
  setup() {
    const editable = ref({});
    const route = useRoute()
    return {
      editable,
      vaults: computed(() => AppState.vaults),
      routeAccount: computed(() => route.name.includes('Account')),
      async addToVault() {
        try {
          let data = {
            keepId: AppState.activeKeep.id, vaultId: editable.value.id
          }

          await vaultsService.addToVault(data)
          Pop.success(`Added to your vault!`)
        } catch (error) {
          console.error('[]', error)
          Pop
            .error(error)
        }
      },

      async removeVaultKeep(id) {
        try {
          if (await Pop.confirm())
            await vaultsService.removeVaultKeep(id)
          } catch (error) {
            console.error('[]',error)
            Pop.error(error)
          }
      }
    };
  },
  components: { RouterLink, AddKeepToVault }
}
</script>


<style lang="scss" scoped>
.keep-name{
  font-family: 'Marko One';
    font-style: normal;
    font-weight: 400;
    font-size: 48px;
    line-height: 64px;
}

.name {
  font-family: 'Oxygen';
  font-style: normal;
  font-weight: 700;
  font-size: 18px;
  line-height: 23px;
}

.pic {
  height: 70vh;
  background-size: cover;

}

option {
  font-family: 'Oxygen';
  font-style: normal;
  font-weight: 700;
  font-size: 20px;
  line-height: 25px;
}

select {
  font-family: 'Oxygen';
  font-style: normal;
  font-weight: 700;
  font-size: 20px;
  line-height: 25px;
}

.save {
  background-color: #A76BBD;
  color: white;

}

.piccy {
  object-fit: fill;
}
</style>