<template>
  <div class="modal fade" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered modal-xl">
      <div class="modal-content">
   

        <slot>

        </slot>

      </div>
    </div>
  </div>
</template>


<script>
export default {
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
.modal{
  background: rgb(2, 0, 36);
    background: linear-gradient(17deg, rgba(2, 0, 36, 1) 0%, rgba(203, 149, 22, 0.6055015756302521) 55%, rgba(115, 236, 196, 0.779171043417367) 100%);
}
</style>