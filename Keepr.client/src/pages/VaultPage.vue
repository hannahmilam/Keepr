<template>
<div class="container-fluid" v-if="vault">
  <div class="row">
    <VaultDetails />
  </div>
</div>
</template>

<script>
import { computed } from '@vue/reactivity'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
import { onMounted, watchEffect } from '@vue/runtime-core'
import { vaultsService } from '../services/VaultsService'
import { Vault } from '../Models/Vault'
import Pop from '../utils/Pop'
import { keepsService } from '../services/KeepsService'
import { logger } from '../utils/Logger'
import { router } from '../router'
export default {
  props: {
    vault: {
      type: Vault,
      default: () => new Vault()
    }
  },
setup(props){
  const route = useRoute()
  watchEffect(async () => {
    try {
       await  vaultsService.getVaultById(route.params.vaultId)
      await keepsService.getKeepsByVaultId(route.params.vaultId)
    } catch (error) {
      // Pop.toast('You Are Not Authorized', 'error')
      router.push({name: 'Home'})

    }
  })
  return{
    vaults: computed(() => AppState.vaults),
    keep: computed(() => AppState.keeps)
  }
}
}
</script>

<style scoped>

</style>