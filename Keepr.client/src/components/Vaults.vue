<template>
<div class="grid-item my-3" v-if="vault != null">
  <!-- <router-link :to="{name: 'Vault', params: {vaultId: vault.id}}" class="selectable"> -->
  <div class="card p-0 m-0 selectable">
    <div class="card-body m-0 p-0">
    <img :src="vault.img" class="card-img" loading="lazy" alt="vault image">
    </div>
    <div class="card-footer m-0 p-0 clip-text">
       <h4>{{vault.name}}</h4>
       <p>{{vault.description}}</p>
    </div>
  </div>
  <!-- </router-link> -->
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
.grid-item{
  display: inline-block;
}
.card{
  max-width: 20rem;
  border-radius: 12px; 
  box-shadow: 0 14px 28px rgba(0,0,0,0.25), 0 10px 10px rgba(0,0,0,0.22)
}
.card-img{
  height: 100%;
  border-radius: 12px;
}
.card-body{
  border-radius: 12px;
}
.card-footer{
  position: absolute;
  width: 100%;
  bottom: 0;
  border: none;
  backdrop-filter: blur(12px);
  background-color: transparent;
  border-radius: 12px;
}
h4 {
  color: white;
  text-transform: uppercase;
  text-shadow: 0 1px 0 black;
  border-radius: 12px; 
}
p {
  color: white;
  text-transform: uppercase;
  text-shadow: 0 1px 0 black;
  border-radius: 12px; 
}
</style>