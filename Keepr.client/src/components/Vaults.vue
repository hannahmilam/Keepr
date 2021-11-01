<template>
<div class="col-3">
  <router-link :to="{name: 'Vault', params: {vaultId: vault.id}}" class="selectable">
  <div class="card selectable">
    <img :src="vault.img" alt="">
    <div class="card-footer clip-text">
       <h3>{{vault.name}}</h3>
       <p>{{vault.description}}</p>
    </div>
  </div>
  </router-link>
</div>

</template>

<script>
import { computed } from '@vue/reactivity'
import { Vault } from '../Models/Vault'
import { AppState } from '../AppState'
export default {
  props: {
    vault: {
      type: Vault,
      default: () => { return new Vault()}
    }
  },
  setup(){
    return{
      vaultKeep: computed(() => AppState.vaultKeeps),
      keeps: computed(() => AppState.keeps.filter(k => k.id === AppState.vaultKeep.keepId))
    }
  }

}
</script>

<style scoped>
.card{
  background-size: cover;
  border-radius: 12px; 
  box-shadow: 0 14px 28px rgba(0,0,0,0.25), 0 10px 10px rgba(0,0,0,0.22)
}
.card > img{
  border-radius: 12px;
  height: 100%;
}
.card-footer{
  position: absolute;
  bottom: 8px;
  color: white;
  text-transform: uppercase;
  text-shadow: 0 1px 0 black;
}
</style>