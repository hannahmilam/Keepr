<template>
<div class="col-6">
  <img :src="keep.img" alt="">
</div>
<div class="col-6">
  <p>{{keep.description}}</p>
</div>

</template>

<script>
import { Keep } from '../Models/Keep'
export default {
props: {
  keep: {
    type: Keep,
    default: () => {return new Keep()}
  }
},
  setup(){
    return{

    }
  }

}
</script>

<style>

</style>