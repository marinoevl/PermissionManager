<template>
        <label class="form-label">{{ label }}</label>       
        <input class="form-control"
               v-bind="$attrs"
               type="date"
               :value="modelValue"
               @input="$emit('update:modelValue',$event.target.value)"
        >
</template>

<script setup>
const props = defineProps(['label', 'modelValue'])

function formatDate(dateString) {
  const date = new Date(dateString);
  return new Intl.DateTimeFormat('default', {dateStyle: 'long'}).format(date);
}

</script>

<style scoped>

</style>