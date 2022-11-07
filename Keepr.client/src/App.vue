<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer class="bg-dark text-light">
    Made with 💖 by CodeWorks
  </footer>
  <ModalComponent id="keep-modal">
    <KeepModal :keep="keep" v-if="keep" />
  </ModalComponent>

  <ModalComponent id="create-keep-modal">
    <CreateKeepModal />
  </ModalComponent>

  <ModalComponent id="create-vault-modal">
    <CreateVaultModal />
  </ModalComponent>

  <ModalComponent id="edit-account-modal">
    <EditAccountModal />
  </ModalComponent>

</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from './AppState'
import KeepModal from "./components/KeepModal.vue"
import CreateKeepModal from "./components/CreateKeepModal.vue"
import ModalComponent from "./components/ModalComponent.vue"
import Navbar from './components/Navbar.vue'
import CreateVaultModal from "./components/CreateVaultModal.vue"
import Pop from "./utils/Pop.js"
import { accountService } from "./services/AccountService.js"
import EditAccountModal from "./components/EditAccountModal.vue"

export default {
  setup() {
    async function getAccountVaults() {
      try {
        await accountService.getAccountVaults()
      } catch (error) {
        console.error('[]', error)
        Pop.error(error)
      }
    }
    // onMounted(() => {
    //   getAccountVaults()
    // })

    return {
      appState: computed(() => AppState),
      keep: computed(() => AppState.activeKeep)
    }
  },
  components: { Navbar, ModalComponent, KeepModal, CreateKeepModal, CreateVaultModal, EditAccountModal }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}


footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
