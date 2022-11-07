<template>
  <div class="component">


    <section class="container mt-3">
      <div class="row justify-content-center">
        <div class="col-md-8 text-center rounded p-5 text-shadow cover" :style="{ backgroundImage: `url(${vault?.img})` }">
          <h1>{{ vault?.name }}</h1>
          <p>by {{ vault?.creator?.name }}</p>
        </div>
      </div>
      <div class="text-center rounded m-3">
        <p class="">
          {{ keeps.length }} Keeps
        </p>
      </div>
    </section>

    <section class="container">
      <div class="masonry my-5">
        <div v-for="k in keeps" :key="k.id">
          <KeepCard :keep="k" />
        </div>
      </div>
    </section>



  </div>

  <button class="btn btn-danger" @click="removeVault()">remove vault</button>
</template>


<script>
import { computed } from "@vue/reactivity";
import { onMounted, watchEffect } from "vue";
import { useRoute } from "vue-router";
import { AppState } from "../AppState.js";
import { router } from "../router.js";
import { vaultsService } from "../services/VaultsService.js";
import Pop from "../utils/Pop.js";

export default {
  setup() {
    const route = useRoute();
    async function getKeepsInVault() {
      try {
        await vaultsService.getKeepsInVault(route.params.id)
      } catch (error) {
        console.error('[keeps in vault]', error)
        Pop.error(error)
      }
    }
    async function setVaultActive() {
      try {
        await vaultsService.setVaultActive(route.params.id)
      } catch (error) {
        console.error('[]', error)
        Pop.error(error)
      }
    }


    onMounted(() => {
      getKeepsInVault()
      setVaultActive()
    })

    return {
      vault: computed(() => AppState.activeVault),
      keeps: computed(() => AppState.keeps),
      async removeVault() {
        try {
          if (await Pop.confirm())
            await vaultsService.removeVault(route.params.id)
        } catch (error) {
          console.error('[]', error)
          Pop.error(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.cover{
  background-size: cover;
  background-position: center;
background-attachment: fixed;
}

.masonry {
  columns: 4;
}

@media screen AND (max-width: 768px) {
  .masonry {
    columns: 2
  }
}
</style>