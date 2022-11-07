<template>
  <div class="component my-2 mx-3 rounded-3 mt-4 elevation-5 hover d-flex"
    :style="{ backgroundImage: `url(${vault.img})` }">
    <div class="d-flex justify-content-between">
      <!-- <h6 class="rounded px-2 py-1 ms-2 mt-2 category">{{ recipe.category }}</h6> -->
      <i class="mdi mdi-lock text-danger" v-if="vault?.isPrivate"></i>

    </div>
    <div class="align-items-end d-flex text-light justify-content-between">

      <router-link :to="{ name: 'Vault', params: { id: vault.id } }">
        <h5 class="text-shadow">{{ vault.name }}</h5>
        <!-- <p class="d-flex justify-content-end">hi</p> -->
      </router-link>
      <!-- <img alt="logo" src="src\assets\img\Vector (3).png" class="m-auto justify-content-end d-flex" /> -->


    </div>
  </div>

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
.component {
  width: 350px;
  height: 250px;
  object-fit: fill;
  background-size: cover;
  background-position: center;
}
</style>