<template>
  <label class="form-label" >{{ label }}</label>
  <input
      v-bind="$attrs"
      :value="modelValue" class="form-control" @input="$emit('update:modelValue',$event.target.value)">
</template>

<script setup>
const props = defineProps(['label', 'modelValue'])

</script>

<style scoped>

</style>