<template>
  <div class="modal-body">
    <form @submit.prevent="createVault()">
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


      <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault" v-model="editable.isPrivate">
      <label class="form-check-label" for="flexCheckDefault">
        IS PRIVATE
      </label>


      <label for="reportRating" class="form-label">Rating:</label>
      <input v-model="editable.img" type="url" class="form-control" id="reportRating">
      <button type="submit" class="btn btn-primary">Save changes</button>
    </form>
  </div>
  <div class="modal-footer">
    <!-- <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button> -->
  </div>

</template>


<script>
import { Modal } from "bootstrap";
import { ref } from 'vue';

import { vaultsService } from "../services/VaultsService.js";

import { logger } from '../utils/Logger.js';
import Pop from '../utils/Pop.js';

export default {
  setup() {
    const editable = ref({})
    return {
      editable,
      async createVault() {
        try {
          await vaultsService.createVault(editable.value)
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