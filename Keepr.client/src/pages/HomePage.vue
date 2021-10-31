<template>
<div class="container-fluid">
  <div class="grid">
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
  column-width: 250px;
}
.grid-item { 
  column-width: 100px;
  width: 80px;
  height: 100%; 
  }
</style>
