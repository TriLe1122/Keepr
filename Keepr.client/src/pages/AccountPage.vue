<template>
  <div class="about text-center">
    <h1>Welcome {{ account.name }}</h1>
    <img class="rounded" :src="account.picture" alt="" />
    <p>{{ account.email }}</p>
  </div>

<section class="container vaults">
  <div class="d-flex">
    <div v-for="v in vaults" :key="v.id">
      <VaultCard :vault="v" />
    </div>
  </div>


</section>


  <section class="container">
    <div class="masonry my-5">
      <div v-for="k in keeps" :key="k.id">
        <KeepCard :keep="k" />
      </div>
    </div>
  
  
  </section>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import VaultCard from "../components/VaultCard.vue"
import { accountService } from "../services/AccountService.js"
import Pop from "../utils/Pop.js"
export default {
    setup() {
        async function getAccountKeeps() {
            try {
                await accountService.getAccountKeeps();
            }
            catch (error) {
                console.error("[]", error);
                Pop.error(error);
            }
        }
        async function getAccountVaults() {
            try {
                await accountService.getAccountVaults();
            }
            catch (error) {
                console.error("[]", error);
                Pop.error(error);
            }
        }
        onMounted(() => {
            getAccountKeeps();
            getAccountVaults();
        });
        return {
            account: computed(() => AppState.account),
            keeps: computed(() => AppState.keeps),
            vaults: computed(() => AppState.vaults)
        };
    },
    components: { VaultCard }
}
</script>

<style scoped>
img {
  max-width: 100px;
}

.vaults{
  /* height: 30rem; */
  width: 80vw;
 /* overflow-y: scroll; */
  overflow-y: hidden;
}

.masonry {
  columns: 4;
}

@media screen AND (max-width: 768px) {
  .masonry {
    columns: 2
  }
}
</style>
