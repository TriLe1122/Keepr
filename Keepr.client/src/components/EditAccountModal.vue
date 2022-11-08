<template>
  <div class="col-md-6 p-5 text-black modal-body">
    <form class=" account-form acc-bio p-3 rounded" @submit.prevent="handleSubmit()">
      <div class="acc-pic text-start">
        <div>
          <label for="name">Name:</label>
          <input type="text" class="form-control" v-model="editable.name">
        </div>
        <!-- <div>
        <label for="email">Email:</label>
        <input type="text" class="form-control" v-model="editable.email">
      </div> -->
        <!-- <div>
        <label for="resume">Resume:</label>
        <input type="text" class="form-control" v-model="editable.resume">
      </div> -->
        <!-- <div class="form-check">
        <input class="form-check-input" type="checkbox" value="" id="flexCheckDefault" v-model="editable.graduated">
        <label class="form-check-label" for="flexCheckDefault">
          Graduated:
        </label>
      </div> -->
        <div>
          <label for="picture">Picture:</label>
          <input type="url" class="form-control" v-model="editable.picture" name="picture" placeholder="picture">
        </div>
        <div>
          <label for="coverImg">Cover Image:</label>
          <input type="url" class="form-control" v-model="editable.coverImg" name="coverImg">
        </div>
        <!-- <div>
        <label for="coverImg">Github:</label>
        <input type="url" class="form-control" v-model="editable.github" name="github">
      </div>
      <div>
        <label for="coverImg">LinkedIn:</label>
        <input type="url" class="form-control" v-model="editable.linkedin" name="LinkedIn">
      </div>
      <div>
        <label for="bio">Bio:</label>
        <textarea type="text" class="form-control" v-model="editable.bio" name="bio" rows="8"
          style="resize:none"></textarea>
      </div> -->
        <div>
          <button type="submit" class="btn btn-primary w-100 mt-2">Save</button>
        </div>
      </div>
    </form>
  </div>
</template>


<script>
import { Modal } from "bootstrap";
import { ref } from "vue";
import { accountService } from "../services/AccountService.js";
import Pop from "../utils/Pop.js";

export default {
  setup() {
    const editable = ref({})
    return {
      editable,

      async handleSubmit() {
        try {

          await accountService.editAccount(editable.value)
          Modal.getOrCreateInstance('#create-keep-modal').hide()
        } catch (error) {
          console.error('[]', error)
          Pop.error(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>

</style>