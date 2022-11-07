<template>
  <div class="component my-2 rounded-3 mt-4 elevation-5 hover" :style="{ backgroundImage: `url(${vault.img})` }">
    <div class="d-flex justify-content-between">
      <!-- <h6 class="rounded px-2 py-1 ms-2 mt-2 category">{{ recipe.category }}</h6> -->


    </div>
    <div class="">
      <p class="title p-1 rounded-2 hoverable" @click="getRecipeDetails()" data-bs-toggle="modal"
        data-bs-target="#exampleModal">{{ vault.name}}</p>
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
  height: 350px;
  position: relative;
  background-size: cover;
  background-position: center;
}

.title {
  position: absolute;
  transform: translateY(14.5rem) translateX(.5rem);
  width: 330px;
  max-height: 70px;
  background-color: rgba(88, 88, 88, 0.853);
  color: rgb(246, 245, 243);
  font-size: large;
}

.category {
  background-color: rgba(88, 88, 88, 0.853);
  color: rgb(246, 245, 243);
}

.heart {
  background-color: rgba(255, 255, 255, 0.607);
}
</style>