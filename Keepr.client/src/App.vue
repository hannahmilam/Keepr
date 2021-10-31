<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>
  <footer>
    <div class="bg-dark text-light d-flex justify-content-center p-4">
      <div class="col-1 text-center">
      <p class="action" @click="scrollToTop">
        Back To Top
      </p>
      </div>
    </div>
  </footer>
</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
export default {
  name: 'App',
  setup() {
    return {
      appState: computed(() => AppState),
      scrollToTop(){
        window.scrollTo(0, 0);
      }
    }
  }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";
main{
background-color: white;
scroll-behavior: smooth;
}
p:hover{
  border-bottom: solid white;
  border-width: 1px;
}

</style>
