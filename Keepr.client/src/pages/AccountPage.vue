<template>
  <div class="container pt-4">



    <div class="col-8 about text-center cover container rounded-5 "
      :style="{ backgroundImage: `url(${account.coverImg})` }">
      <div class=" info mb-5">
        <img class="rounded-circle border border-white border-4" height="100" width="150" :src="account.picture " alt="" />
        <p class="name">{{ account.name }}</p>
        <p class="fs-1">
          {{ vaults.length }} Vaults | {{ keeps.length }} Keeps
        </p>
      </div>
    </div>


    <div class="container-fluid">
      <div class="dropdown mt-5">
        <i class="mdi mdi-dots-horizontal fs-1 " type="button" data-bs-toggle="dropdown" aria-expanded="false"></i>
        <ul class="dropdown-menu">
          <li data-bs-toggle="modal" data-bs-target="#edit-account-modal">Edit Account</li>
          <!-- <li><a class="dropdown-item" href="#">Another action</a></li> -->
          <!-- <li><a class="dropdown-item" href="#">Something else here</a></li> -->
        </ul>
      </div>
      <section class="container vaults mt-5">
        <div class="d-flex">
          <div v-for="v in vaults" :key="v.id">
            <VaultCard :vault="v" />
          </div>
        </div>
      </section>
    </div>

    <section class="container">
      <div class="masonry my-5">
        <div v-for="k in keeps" :key="k.id">
          <KeepCard :keep="k" />
        </div>
      </div>
    </section>
  </div>

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
  background-size: cover;
  height: 25rem;
  background-position: center;
  /* background-attachment: fixed; */
  /* object-fit: fill; */
  position: relative;
}

.name{
  font-weight: 400;
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

.info {
  position: absolute;
 margin-top: 22rem;
 margin-left: 16rem;
font-family: 'Oxygen';
  font-style: normal;
  /* font-weight: 700; */
  font-size: 48px;
  line-height: 61px;
}

@media screen AND (max-width: 768px) {
  .masonry {
    columns: 2
  }
}
</style>
