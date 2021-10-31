<template>
<div class="col-md-3 my-3">
  <div class="card shadow p-0 m-0" :style="{ 'backgroundImage': `url(${keep.img})` }">
    <div class="card-footer m-0 p-0">
      <div class="row mt-1 pb-1 justify-content-around">
      <div class="col-8">
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
  border-radius: 12px; 

}
.card-footer{
  position: relative;
  bottom: -17rem;
  border: none;
  background-color: transparent;
   backdrop-filter: blur(12px);
  -webkit-backdrop-filter: blur(12px);
    border-bottom-left-radius: 12px;
    border-bottom-right-radius: 12px;

}
h3 {
  color: white;
  text-transform: uppercase;
  text-shadow: 0 1px 0 black;
  border-radius: 12px; 

}
</style>