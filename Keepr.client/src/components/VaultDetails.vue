<template>
<div class="row ms-3 justify-content-between">
  <div class="col-6">
<h1>{{vault?.name}}</h1>
<small>Keeps: {{keeps.length}}</small>
</div>
<div class="col-2 text-center" v-if="account?.id === vault?.creatorId">
  <button class="btn btn-outline-secondary" @click="deleteVault(vault.id)">Delete Vault</button>
</div>
</div>
<div class="grid" v-if="keeps.length > 0">
  <VaultKeeps v-for="k in keeps" :key="k.id" :keep="k" />
</div>
<div class="row" v-else>
  <img src="https://images.unsplash.com/photo-1591178761188-885caa0b4fc3?ixid=MnwxMjA3fDB8MHxzZWFyY2h8M3x8Y29sbGFnZXxlbnwwfHwwfHw%3D&ixlib=rb-1.2.1&auto=format&fit=crop&w=800&q=60"  alt="">
</div>
</template>

<script>
import { computed } from '@vue/reactivity'
import { AppState } from '../AppState'
import { Keep } from '../Models/Keep'
import { Vault } from '../Models/Vault'
import { useRoute } from 'vue-router'
import { vaultsService } from '../services/VaultsService'
import Pop from '../utils/Pop'
import { logger } from '../utils/Logger'
import { router } from '../router'
export default {
 setup(){
   const route = useRoute()
    return{
      account: computed(() => AppState.account),
      vault: computed(() => AppState.vault),
      vaultKeep: computed(() => AppState.vaultKeeps),
      keeps: computed(() => AppState.keeps),
      async deleteVault(vaultId){
        try {
          if(await Pop.confirm()){
            await vaultsService.deleteVault(route.params.vaultId)
            router.push({name: 'Home'})
            Pop.toast('Vault Deleted')
          }
        } catch (error) {
          Pop.toast(error.message, 'error')
          logger.log('DELETE_VAULT_ERROR', error.message)
        }
      }
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