<template>
  <router-link :to="{ name: 'Vault', params: { id: vault.id } }">
  <div class="component hover my-2 mx-3 rounded-3 mt-4 elevation-5 hover d-flex justify-content-between align-items-end"
    :style="{ backgroundImage: `url(${vault.img})` }">
    <div class="d-flex justify-content-between">
      <!-- <h6 class="rounded px-2 py-1 ms-2 mt-2 category">{{ recipe.category }}</h6> -->



      <div class="align-items-end d-flex text-light justify-content-between">

          <h1 class="text-shadow vault-name ms-4 mb-2">{{ vault.name }}</h1>
          <!-- <p class="d-flex justify-content-end">hi</p> -->
          <!-- <i class="mdi mdi-lock fs-4"></i> -->
          <!-- <img alt="logo" src="src\assets\img\Vector (3).png" class="m-auto justify-content-end d-flex" /> -->
          
        </div>
      </div>
      <div>
        <i class="mdi mdi-lock text-shadow fs-2  rounded-circle" v-if="vault.isPrivate"></i>
        <!-- <i class="mdi mdi-lock text-danger" v-if="vault?.isPrivate"></i> -->
        
      </div>
    </div>
  </router-link>

</template>


<script>
import { Vault } from "../models/Vault.js";




export default {
  props: {
    vault: {
      type: Vault,
      required: true
    }
  },
  setup(props) {
    return {

    }
  }
}
</script>


<style lang="scss" scoped>
.vault-name {
  font-family: 'Quando';
  font-style: normal;
  font-weight: 500;
  font-size: 24px;
  line-height: 30px;
}

.component {
  width: 350px;
  height: 250px;
  // object-fit: fill;
  background-size: cover;
  background-position: center;
}
</style>