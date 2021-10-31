<template>
<div class="container-fluid" v-if="profile != null">
  <div class="row">
    <div class="col-md-2">
    <img :src="profile?.picture" height="90" class="rounded" alt="">
    </div>
    <div class="col">
      <h2>{{profile?.name}}</h2>
      <small>Vaults: {{vaults.length}}</small><br/>
      <small>Keeps: {{keeps.length}} </small>
    </div>
  </div>
  <div class="row mt-5">
    <h3>Vaults <i class="mdi mdi-plus text-secondary action" data-bs-toggle="modal" data-bs-target="#vault-form"></i></h3>
  <Vaults v-for="v in vaults" :key="v.id" :vault="v"/>
  </div>
  <div class="row mt-5">
    <h3>Keeps <i class="mdi mdi-plus text-secondary action" data-bs-toggle="modal" data-bs-target="#keep-form"></i></h3>
  </div>
  <div class="grid">
    <Keeps v-for="k in keeps" :key="k.id" :keep="k"/>
  </div>
</div>

<Modal id="vault-form">
    <template #modal-body>
      <VaultForm />
    </template>
  </Modal>

<Modal id="keep-form">
    <template #modal-body>
      <KeepForm/>
    </template>
  </Modal>
</template>

<script>
import { computed } from '@vue/reactivity'
import { AppState } from '../AppState'
import { onMounted } from '@vue/runtime-core'
import { vaultsService } from '../services/VaultsService'
import { keepsService } from '../services/KeepsService'
import { profilesService } from '../services/ProfilesService'
import { useRoute } from 'vue-router'
export default {
  setup(){
    const route = useRoute()
    onMounted(() => {
      vaultsService.getVaultsByProfile(route.params.id)
      keepsService.getKeepsByProfile(route.params.id)
      profilesService.getProfileById(route.params.id)
      
    })
    return{
      account: computed(() => AppState.account),
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps),
      profile: computed(() => AppState.currentProfile)
    }
  }
}
</script>
<style scoped>
.grid{
  column-width: 300px;
  margin: 20px auto;
}
.grid-item { 
  column-width: 50px;
  width: 100%;
  height: 100%; 
  }
</style>
