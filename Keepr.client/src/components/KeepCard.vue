<template>
  <div class="card text-bg-dark border-0 my-3 elevation-5">
    <img :src="keep.img" class="card-img img-fluid" alt="...">
    <div class="card-img-overlay align-items-end d-flex justify-content-between">
      <h5 class="card-title" @click="getKeepDetails()" data-bs-toggle="modal" data-bs-target="#keep-modal">{{ keep.name }}</h5>
      <img :src="keep.creator.picture" class="person rounded-circle" alt="" height="40" width="40">

    </div>
  </div>
</template>

<script>
import { computed } from "@vue/reactivity";
import { onMounted, ref, watchEffect } from "vue";
import { AppState } from "../AppState.js";
import { logger } from "../utils/Logger.js"
import Pop from "../utils/Pop.js";
import { Keep } from "../models/Keep.js";
import { keepsService } from "../services/KeepsService.js";

export default {
  props: {
    keep: {
      type: Keep,
      required: true
    }
  },
  setup(props) {
    const editable = ref({});

    onMounted(() => {

    });
    watchEffect(() => { });

    return {
      editable,
      async getKeepDetails() {
        try {
          await keepsService.getKeepDetails(props.keep.id);
          } catch (error) {
            console.error('[]',error)
            Pop.error(error)
          }
      }
      
    }
  }
}
</script>

<style lang="scss" scoped>
.person {}
</style>