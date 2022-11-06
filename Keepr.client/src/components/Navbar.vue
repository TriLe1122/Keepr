<template>
  <nav class="navbar navbar-expand-lg navbar-white bg-white px-3 d-flex justify-content-between elevation-3 fixed-top">
    <div class="d-flex">
      <router-link class="" :to="{ name: 'Home' }">
        <button class="button btn border border-3 me-3 hover">Home</button>
      </router-link>
      <div class="dropdown">
        <button class="btn btn border border-3 dropdown-toggle dropdown-toggle-split" type="button" data-bs-toggle="dropdown"
          aria-expanded="false">
          Create
        </button>
        <ul class="dropdown-menu text-center p-0">
          <li data-bs-toggle="modal" data-bs-target="#create-keep-modal">new keep</li>
          <li>
            <hr class="dropdown-divider">
          </li>
          <li>new vault</li>
        </ul>
      </div>
    </div>
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <img alt="logo" src="src\assets\img\Keepr logo.png" class="bg-white" height="45" />
      </div>
    </router-link>
    <Login class="hover" />
  </nav>
</template>

<script>
import Login from './Login.vue'
export default {
  setup() {
    return {}
  },
  components: { Login }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

@media screen and (min-width: 768px) {
  nav {
    height: 64px;
  }
}
</style>
