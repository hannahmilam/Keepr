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
body{
  padding: 1em;
  background: #2B3134;
  color: #777;
  text-align: center;
  font-family: "Gill sans", sans-serif;
  width: 80%;
  margin: 0 auto;
}
h1{
  margin: 1em 0;
  border-bottom: 1px dashed;
  padding-bottom: 1em;
  font-weight: lighter;
}
p{
  font-style: italic;
}
.loader{
  margin: 0 0 2em;
  height: 100px;
  width: 20%;
  text-align: center;
  padding: 1em;
  margin: 0 auto 1em;
  display: inline-block;
  vertical-align: top;
}
</style>
