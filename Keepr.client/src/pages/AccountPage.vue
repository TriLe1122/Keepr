<template>
  <div class="about text-center cover container rounded "  :style="{ backgroundImage: `url(${account.coverImg})` }">
    
    <div class=" info">
      <img class="rounded-circle" :src="account.picture" alt="" />
      <h1>{{ account.name }}</h1>
      <p class="fs-1">
        {{ vaults.length }} Vaults | {{ keeps.length }} Keeps
      </p>
    </div>



  </div>

  <div class="dropdown">
    <i class="mdi mdi-dots-horizontal fs-1 " type="button" data-bs-toggle="dropdown" aria-expanded="false"></i>
    <ul class="dropdown-menu">
      <li data-bs-toggle="modal" data-bs-target="#edit-account-modal">Edit Account</li>
      <!-- <li><a class="dropdown-item" href="#">Another action</a></li> -->
      <!-- <li><a class="dropdown-item" href="#">Something else here</a></li> -->
    </ul>
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
.cover {
  /* background-image: url(https://images.unsplash.com/photo-1502394202744-021cfbb17454?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=983&q=80); */
  background-size: contain;
  height: 25rem;
  background-position: center;
  background-attachment: fixed;
  object-fit: fill;

}


img {
  max-width: 100px;
}

.vaults {
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
