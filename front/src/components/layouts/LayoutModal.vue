<template>
  <modal id="layoutModal">
    <template v-slot:header>
      <h3>{{ header }}</h3>
    </template>
    <template v-slot:body>
      <h1>{{ body }}</h1>
    </template>
    <template v-slot:footer>
      <h3>{{ footer }}</h3>
    </template>
  </modal>
</template>

<script>
  import Modal from '@/components/Modal.vue';

  export default {
    name: 'LayoutModal',
    components: { Modal },
    props: {
      header: {
        type: String,
        required: true,
      },
      body: {
        type: String,
        required: true,
      },
      footer: {
        type: String,
        required: true,
      },
    },
  };
</script>
