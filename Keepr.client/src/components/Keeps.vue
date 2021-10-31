<template>
<div class="col-md-3">
  <div class="card shadow" :style="{ 'backgroundImage': `url(${keep.img})` }">
    <div class="card-footer">
      <div class="row">
      <div class="col-10">
      <h3>{{keep.name}}</h3>
      </div>
      <div class="col-2">
        <img :src="keep.creator?.picture" class="rounded-circle" height="35" alt="">
      </div>
      </div>
    </div>
</div>
  </div>
</template>

<script>
import { computed } from '@vue/reactivity'
import { AppState } from '../AppState'
import { Keep } from '../Models/Keep'
export default {
  props: {
    keep: { 
      type: Keep,
      default: () => { return new Keep()}
    }
  },
setup(){
  return{

  }
}
}
</script>

<style scoped style="scss">
.card{
  height: 20rem;
  background-size: cover;
}
.card-footer{
  position: relative;
  bottom: -17rem;
  border: none;
  background-color: transparent;
   backdrop-filter: blur(12px);
  -webkit-backdrop-filter: blur(12px);
}
h3 {
  color: white;
  text-transform: uppercase;
  text-shadow: 0 1px 0 black;
}
</style>