<template>
<div class="grid-item my-3">
  <div class="card p-0 m-0 selectable" data-bs-toggle="modal" data-bs-target="#keep-details" :style="{ 'backgroundImage': `url(${keep.img})` }">
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


<Modal id="keep-details">
    <template #modal-body>
      <KeepDetails :keep="keep"/>
    </template>
  </Modal>
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
  box-shadow: 0 14px 28px rgba(0,0,0,0.25), 0 10px 10px rgba(0,0,0,0.22)
}
.card-footer{
  position: relative;
  bottom: -17rem;
  border: none;
  background-color: transparent;
}
h3 {
  color: white;
  text-transform: uppercase;
  text-shadow: 0 1px 0 black;
  border-radius: 12px; 

}

  /* @media only screen and (max-width: 768px) {
     .hidden-text {
       display: none;
     } */
</style>