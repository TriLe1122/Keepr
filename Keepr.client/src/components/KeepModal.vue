<template>
  <div class="modal-body p-0">
    <div class="row">
      <div class="col-md-6 pic rounded-start" :style="{ backgroundImage: `url(${keep.img})` }">
        <!-- <img :src="keep.img" alt="" class="img-fluid rounded-start h-100 piccy"> -->
      </div>

      <div class="col-md-6 d-flex flex-column justify-content-between ">

        <div class="text-center">
          <img alt="logo" src="src\assets\img\Vector (2).png"> {{ keep.views }}
          <img alt="logo" src="src\assets\img\Logo.png">
        </div>

        <div>
          <h4>
            {{ keep.name }}
          </h4>
          <p>
            {{ keep.description }}
          </p>
        </div>
        <div class="d-flex justify-content-end">
          <router-link :to="{ name: 'Profile', params: { id: keep.creator.id } }">
            <img :src="keep.creator.picture" alt="" class="rounded-circle" height="40" width="40"
              data-bs-dismiss="modal">
          </router-link>
          <p>{{ keep.creator.name }}</p>
        </div>


      </div>
    </div>
  </div>
</template>


<script>

import { RouterLink } from "vue-router";
import { Keep } from "../models/Keep.js";

export default {
  props: {
    keep: {
      type: Keep,
      required: true
    }
  },
  setup() {
    return {};
  },
  components: { RouterLink }
}
</script>


<style lang="scss" scoped>
.pic {
  height: 70vh;
  background-size: cover;

}

.piccy {
  object-fit: fill;
}
</style>