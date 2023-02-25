<template>
  <div v-for="g in grid">{{ g }}</div>
</template>

<script>
  export default {
    name: 'mainPage',
    data() {
      return {
        grid: 1000,
      };
    },
  };
</script>
