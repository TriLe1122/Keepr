<template>
  <div class="modal-body">
    <div class="row">
      <div class="col-md-6">

        <form @submit.prevent="createKeep()">
          <div class="form-floating mb-3">
            <input v-model="editable.name" required type="text" class="form-control" placeholder="Title...">
            <label for="reportTitle">Keep Name</label>
          </div>
          <div class="form-floating mb-3">
            <textarea v-model="editable.description" required type="text" class="form-control" placeholder="Body...">
          </textarea>
            <label for="reportBody">Description</label>
          </div>
          <label for="reportRating" class="form-label">Image!</label>
          <input v-model="editable.img" type="url" class="form-control">
          <button type="submit" class="btn btn-primary">Save changes</button>
        </form>
      </div>
      <div class="col-md-6 input-image rounded d-flex" :style="{ backgroundImage: `url(${editable.img})` }">
        <!-- <img :src="editable.img" alt=""> -->
        <p class="text-white d-flex align-items-end">{{editable.name}}</p>
      </div>
    </div>

  </div>


</template>


<script>
import { Modal } from "bootstrap";
import { ref } from 'vue';
import { keepsService } from "../services/KeepsService.js";

import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';

export default {
  setup() {
    const editable = ref({})
    return {
      editable,
      async createKeep() {
        try {
          await keepsService.createKeep(editable.value)
          Modal.getOrCreateInstance('#create-keep-modal').hide()
          Pop.success("Created a Keep!")
        } catch (error) {
          logger.error(error)
          Pop.error(error.message)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>

.input-image{
  object-fit: cover;
  background-size: cover;
  background-position: center;
  height: 30rem;
}

</style>