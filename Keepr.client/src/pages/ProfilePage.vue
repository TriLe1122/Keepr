<template>
  <div class="component">
{{profile.name}}
  </div>
</template>


<script>
import { computed } from "@vue/reactivity";
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

    onMounted(() => {
      getProfile()
    })
    return {
      profile: computed(() => AppState.profile)
    }
  }
}
</script>


<style lang="scss" scoped>

</style>