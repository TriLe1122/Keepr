<template>
  <div class="component">
    vault page
 <button class="btn btn-danger" @click="removeVault()">remove vault</button>
  </div>
</template>


<script>
import { onMounted, watchEffect } from "vue";
import { useRoute } from "vue-router";
import { AppState } from "../AppState.js";
import { router } from "../router.js";
import { vaultsService } from "../services/VaultsService.js";
import Pop from "../utils/Pop.js";

export default {
  setup() {
    const route = useRoute();
    async function getKeepsInVault() {
      try {
        await vaultsService.getKeepsInVault(route.params.id)
      } catch (error) {
        console.error('[keeps in vault]', error)
        Pop.error(error)
      }
    }
    async function setVaultActive() {
      try {
          await vaultsService.setVaultActive(route.params.id)
        } catch (error) {
          console.error('[]',error)
          Pop.error(error)
        }
    }

    // watchEffect(() => {
    //   if (!AppState.activeVault) {
    //     router.push({ name: 'Home'})
    //   }
    // })

    onMounted(() => {
      getKeepsInVault()
      setVaultActive()
    })

    return {
      async removeVault() {
        try {
          if (await Pop.confirm())
            await vaultsService.removeVault(route.params.id)
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

</style>