<template>
  <div class="modal-body">
    <form @submit.prevent="createKeep()">
      <div class="form-floating mb-3">
        <input v-model="editable.name" required type="text" class="form-control" id="reportTitle"
          placeholder="Title...">
        <label for="reportTitle">Report Title</label>
      </div>
      <div class="form-floating mb-3">
        <textarea v-model="editable.description" required type="text" class="form-control" id="reportBody"
          placeholder="Body...">
          </textarea>
        <label for="reportBody">Report Body</label>
      </div>
      <label for="reportRating" class="form-label">Rating:</label>
      <input v-model="editable.img" type="url" class="form-control" id="reportRating">
    </form>
  </div>
  <div class="modal-footer">
    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
    <button type="submit" class="btn btn-primary">Save changes</button>
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

</style>