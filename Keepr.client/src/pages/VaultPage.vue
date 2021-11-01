<template>
<div class="container-fluid">
  <div class="row">
    <VaultDetails />
  </div>
</div>
</template>

<script>
import { computed } from '@vue/reactivity'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
import { onMounted } from '@vue/runtime-core'
import { vaultsService } from '../services/VaultsService'
import { Vault } from '../Models/Vault'
import Pop from '../utils/Pop'
import { keepsService } from '../services/KeepsService'
import { logger } from '../utils/Logger'
export default {
  props: {
    vault: {
      type: Vault,
      default: () => new Vault()
    }
  },
setup(props){
  const route = useRoute()
  onMounted(async () => {
    try {
      await vaultsService.getVaultById(route.params.vaultId)
      await keepsService.getKeepsByVaultId(route.params.vaultId)
    } catch (error) {
      Pop.toast(error.message, 'error')
      logger.log()
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