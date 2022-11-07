<template>
  <div class="component">
hi
<h1 class="mt-5 text-danger" >kkkkkkkkkkkkkkkkkkkkkkkkkkkkk</h1>
  </div>
</template>


<script>
import { computed } from "@vue/reactivity";
import { Modal } from "bootstrap";
import { onMounted } from "vue";
import { useRoute } from "vue-router";
import { AppState } from "../AppState.js";
import { profilesService } from '../services/profilesService.js';
import Pop from "../utils/Pop.js";

export default {
  setup() {
    const route = useRoute();
    async function getProfile() {
      try {
        await profilesService.getProfile(route.params.id)
        } catch (error) {
          console.error('[]',error)
          Pop.error(error)
        }
    }

    async function getProfileVaults() {
      try {
        await profilesService.getProfileVaults(route.params.id)
      } catch (error) {
        console.error('[]', error)
        Pop.error(error)
      }
    }

    async function getProfileKeeps() {
      try {
        await profilesService.getProfileKeeps(route.params.id)
      } catch (error) {
        console.error('[]', error)
        Pop.error(error)
      }
    }


    onMounted(() => {
      getProfile()
      getProfileKeeps()
      getProfileVaults()
    })
    return {
      profile: computed(() => AppState.activeProfile)
    }
  }
}
</script>


<style lang="scss" scoped>

</style>