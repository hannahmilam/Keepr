<template>
<div class="container-fluid">
  <div class="grid text-center">
      <Keeps v-for="k in keeps" :key="k.id" :keep="k"/>
  </div>
</div>
</template>

<script>
import { computed, onMounted } from '@vue/runtime-core'
import { AppState } from '../AppState'
import {vaultsService} from '../services/VaultsService'
import {keepsService} from '../services/KeepsService'
export default {
  setup(){
    onMounted(() => {
      keepsService.getKeeps()
    })
    return{
      vaults: computed(() => AppState.vaults),
      keeps: computed(() => AppState.keeps)
    }
  }
}
</script>

<style scoped lang="scss">
.grid{
  columns: 4 200px;
  column-gap: 1rem;
  flex-wrap: wrap;
  flex-direction: column;
}
</style>
