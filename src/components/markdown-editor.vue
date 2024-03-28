<template>
  <div class="flex flex-wrap">
    <button @click="applyBold" class="button">
      <i class="bi bi-type-bold" />
    </button>
    <button @click="applyItalics" class="button">
      <i class="bi bi-type-italic" />
    </button>
    <button @click="applyHeading1" class="button">
      <i class="bi bi-type-h1" />
    </button>
    <button @click="applyHeading2" class="button">
      <i class="bi bi-type-h2" />
    </button>
    <button @click="applyHeading3" class="button">
      <i class="bi bi-type-h3" />
    </button>
    <button @click="applyHeading4" class="button">
      <i class="bi bi-type-h4" />
    </button>
    <button @click="applyHeading5" class="button">
      <i class="bi bi-type-h5" />
    </button>
    <button @click="applyHeading6" class="button">
      <i class="bi bi-type-h6" />
    </button>
    <button @click="applyOrderedList" class="button">
      <i class="bi bi-list-ol" />
    </button>
    <button @click="applyUnorderedList" class="button">
      <i class="bi bi-list-ul" />
    </button>
    <button @click="applyChecklist" class="button">
      <i class="bi bi-check2-square" />
    </button>
    <button @click="undo" class="button">
      <i class="bi bi-arrow-counterclockwise" />
    </button>
    <button @click="redo" class="button">
      <i class="bi bi-arrow-clockwise" />
    </button>
    <div
      @input="onInput"
      v-html="innerValue"
      contentedittable="true"
      class="border border-primary rounded p-2"
      style="resize: none"
    />
  </div>
</template>

<script lang="ts">
import "bootstrap-icons/font/bootstrap-icons.css";

export default {
  name: "MarkdownEditor",

  props: ["value"],

  data() {
    return {
      innerValue: this.value || '<p><br></p>',
    };
  },

  methods: {
    onInput(event) {
      this.$emit("input", event.target.innerHTML);
    },
    applyBold() {},
    applyItalics() {},
    applyHeading1() {},
    applyHeading2() {},
    applyHeading3() {},
    applyHeading4() {},
    applyHeading5() {},
    applyHeading6() {},
    applyOrderedList() {},
    applyUnorderedList() {},
    applyChecklist() {},
    undo() {},
    redo() {}
  },
};
</script>

<style>
.button {
  @apply border-2;
  @apply border-gray-300;
  @apply rounded-lg;
  @apply px-3 py-1;
  @apply mb-3 mr-3;
}

.button:hover {
  @apply border-green-300;
}
</style>
