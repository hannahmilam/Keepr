<template>
<div class="container-fluid" v-if="keeps">
  <div class="row mb-5">
    <div class="col-md-1 me-5">
    <img :src="profile?.picture" height="120" class="rounded" alt="">
    </div>
    <div class="col">
      <h2>{{profile?.name}}</h2>
      <small>Vaults: {{vaults.length}}</small>
      <br/>
      <small>Keeps: {{keeps.length}} </small>
    </div>
  </div>
    <h3>Vaults <i class="mdi mdi-plus text-info action" data-bs-toggle="modal" data-bs-target="#vault-form"></i></h3>
  <div class="grid">
  <Vaults v-for="v in vaults" :key="v.id" :vault="v"/>
  </div>


    <h3>Keeps <i class="mdi mdi-plus text-info action" data-bs-toggle="modal" data-bs-target="#keep-form"></i></h3>
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
import { logger } from '../utils/Logger'
export default {
  setup(){
    const route = useRoute()
    onMounted(() => {
      vaultsService.getVaultsByProfile(route.params.profileId)
      keepsService.getKeepsByProfile(route.params.profileId)
      profilesService.getProfileById(route.params.profileId)
      
    })
    return{
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults.filter(v => v.creator.id === route.params.profileId)),
      profile: computed(() => AppState.currentProfile)
    }
  }
}
</script>
<style scoped>
.grid{
  columns: 4 200px;
  column-gap: 1rem;
  flex-wrap: wrap;
  flex-direction: column;
}
</style>
