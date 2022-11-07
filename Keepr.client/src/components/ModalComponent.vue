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
.modal {
  // background: rgb(2, 0, 36);
  //   background: linear-gradient(17deg, rgba(2, 0, 36, 1) 0%, rgba(203, 149, 22, 0.6055015756302521) 55%, rgba(115, 236, 196, 0.779171043417367) 100%);

  background: rgb(81, 51, 101);
  background: linear-gradient(34deg, rgba(81, 51, 101, 1) 0%, rgba(253, 29, 29, 0.46544555322128855) 50%, rgba(186, 125, 39, 1) 100%);
}
</style>