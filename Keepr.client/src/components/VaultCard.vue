<template>
  <div class="component my-2 mx-3 rounded-3 mt-4 elevation-5 hover d-flex" :style="{ backgroundImage: `url(${vault.img})` }">
    <div class="d-flex justify-content-between">
      <!-- <h6 class="rounded px-2 py-1 ms-2 mt-2 category">{{ recipe.category }}</h6> -->


    </div>
    <div class="align-items-end d-flex text-light">
      <h5>{{vault.name}}</h5>
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