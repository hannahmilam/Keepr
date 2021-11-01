<template>
<div class="container-fluid">
  <div class="row">
<p>tesing from vault page</p>
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
export default {
setup(){
  return{
  }
}
}
</script>

<style>

</style>