<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-white px-3">
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center">
        <img
          alt="logo"
          src="../assets/img/logo.png"
          height="60"
        />
      </div>
    </router-link>
    <button
      class="navbar-toggler"
      type="button"
      data-bs-toggle="collapse"
      data-bs-target="#navbarText"
      aria-controls="navbarText"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon" />
    </button>
    <div class="collapse navbar-collapse" id="navbarText">
      <ul class="navbar-nav me-auto">
        <li>
         
        </li>
      </ul>

<ul class="navbar-nav me-auto">
       <li>
          <div>
    <form @submit.prevent="findKeepsByQuery" class="bg-white rounded elevation-1">
      <div class="form-group d-flex align-items-center">
        <label for="search" class="sr-only"></label>
        <input v-model="query"
               type="text"
               name="search"
               required
               class="form-control bg-white border-0"
               placeholder="search"
        >
        <button class="btn px-2 py-0 selectable">
          <i class="mdi mdi-magnify"></i>
        </button>
      </div>
    </form>
  </div>
  </li>
</ul>

      <span class="navbar-text">
        <button
          class="btn selectable text-uppercase my-2 my-lg-0"
          @click="login"
          v-if="!user.isAuthenticated"
        >
          Login
        </button>

        <div class="dropdown row my-2 my-lg-0" v-else>
          <div class="col-2">
          <router-link :to="{ name: 'Profile', params: {profileId: account.id} }" class="action">
            <img
              :src="user.picture"
              alt="user photo"
              height="40"
              class="rounded"
            />
          </router-link>
          </div>
          <div class="col-5">
          <div
            class="dropdown-toggle action"
            data-bs-toggle="dropdown"
            aria-expanded="false"
            id="authDropdown"
          >
            <span class="mx-3">{{ user.name }}</span>
          </div>
          
          <div
            class="dropdown-menu p-0 list-group w-100"
            aria-labelledby="authDropdown"
          >
         
            <router-link :to="{ name: 'Account' }">
              <div class="list-group-item list-group-item-action hoverable">
                Manage Account
              </div>
            </router-link>
            <div
              class="list-group-item list-group-item-action hoverable text-danger"
              @click="logout"
            >
              <i class="mdi mdi-logout"></i>
              logout
            </div>
             </div>
          </div>
        </div>
      </span>
    </div>
  </nav>
</template>

<script>
import { AuthService } from '../services/AuthService'
import { AppState } from '../AppState'
import { computed, ref } from 'vue'
import { keepsService } from '../services/KeepsService'
import Pop from '../utils/Pop'
import { vaultsService } from '../services/VaultsService'
export default {
  setup() {
       const query = ref('')
    return {
      query,
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      async login() {
        AuthService.loginWithPopup()
      },
      async logout() {
        AuthService.logout({ returnTo: window.location.origin })
      },
      async findKeepsByQuery(){
        try {
          await keepsService.searchKeeps(query.value)
          await vaultsService.searchVaults(query.value)
        } catch (error) {
          Pop.toast(error.message, 'error')
        }
      }
    }
  }
}
</script>

<style scoped>
.dropdown-menu {
  user-select: none;
  display: block;
  transform: scale(0);
  transition: all 0.15s linear;
 
}
.dropdown-menu.show {
  transform: scale(1);
}
.hoverable {
  cursor: pointer;
}
a:hover {
  text-decoration: none;
}
.nav-link{
  text-transform: uppercase;
}
.navbar-nav .router-link-exact-active{
  border-bottom: 2px solid var(--bs-dark);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}
</style>
