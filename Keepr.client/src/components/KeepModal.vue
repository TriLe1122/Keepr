<template>
  <div class="modal-body p-0">
    <div class="row">
      <div class="col-md-6 pic">
        <img :src="keep.img" alt="" class="img-fluid rounded-start">
      </div>

      <div class="col-md-6 d-flex flex-column justify-content-between ">

       <div class="text-center">
        <img alt="logo" src="src\assets\img\Vector (2).png">
        <img alt="logo" src="src\assets\img\Logo.png">
       </div>

       <div>
        <h4>
          {{keep.name}}
        </h4>
        <p>
          {{keep.description}}
        </p>
       </div>
        <router-link :to="{ name: 'Profile', params: { id: keep.creator.id} }" data-bs-dismiss-modal>
          <img :src="keep.creator.picture" alt="" class="rounded-circle" height="40" width="40">

        </router-link>
      </div>
    </div>
</div>
</template>


<script>

import { Keep } from "../models/Keep.js";

export default {

  props: {
    keep: {
      type: Keep,
      required: true
    }
  },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
.pic{

    
}
</style>