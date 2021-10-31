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
      <div class="row">
      <div class="col-md-6">
      <img :src="keep.img" class="details-img rounded-start" alt="">
      </div>

      <div class="col-md-6">
        <h2 class="text-center">{{keep.name}}</h2>
        <p class="mx-3">{{keep.description}}</p>

      <div class="row mb-2 justify-content-around">
        <div class="col-5 text-center m-0 p-0">
        <button class="btn btn-outline-info m-0 px-1"><small>ADD TO VAULT</small></button>
        </div>
        <div class="col-1 text-center m-0 p-0">
          <i class="mdi mdi-delete"></i>
        </div>
        <div class="col-5 text-center m-0 p-0">
          <img :src="keep.creator?.picture" height="40" class="rounded-circle" alt="">
          </div>
          </div>
        </div>
      </div>
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

.details-img{
  background-size: cover;
  width: 100%;
}

  @media only screen and (max-width: 768px) {
     .hidden-text {
       display: none;
     }
 }
</style>