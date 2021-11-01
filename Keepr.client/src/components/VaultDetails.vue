<template>
<div class="row ms-3 justify-content-between" v-if="vault">
  <div class="col-6">
<h1>{{vault?.name}}</h1>
<small>Keeps: {{keeps.length}}</small>
</div>
<div class="col-2 text-center">
  <button class="btn btn-outline-secondary">Delete Vault</button>
</div>
</div>
<div class="grid">
  <Keeps v-for="k in keeps" :key="k.id" :keep="k" />
</div>
</template>

<script>
import { computed } from '@vue/reactivity'
import { AppState } from '../AppState'
import { Keep } from '../Models/Keep'
import { Vault } from '../Models/Vault'
import { useRoute } from 'vue-router'
export default {
 setup(){
   const route = useRoute()
    return{
      account: computed(() => AppState.account),
      vault: computed(() => AppState.vault),
      vaultKeep: computed(() => AppState.vaultKeeps),
      keeps: computed(() => AppState.keeps)
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