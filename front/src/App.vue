<template>
  <div
    id="overgroundHeightMeterDiv"
    class="fixed-bottom heightMeter"
    v-if="currentLayout === overgroundLayout.name">
    <span>
      <span id="overgroundHeightMeterNumberDiv" class="heightMeterNumber">{{ mousePosition }} </span
      >м над уровнем моря
    </span>
  </div>
  <div
    id="zeroHeightMeterDiv"
    class="fixed-bottom heightMeter"
    v-else-if="currentLayout === zeroLayout.name">
    <span id="zeroHeightMeterNumberSpan" class="heightMeterNumber">нулевой уровень</span>
  </div>
  <div
    id="undergroundHeightMeterDiv"
    class="fixed-bottom heightMeter"
    v-else-if="currentLayout === undergroundLayout.name">
    <span>
      на
      <span id="undergroundHeightMeterNumberSpan" class="heightMeterNumber"
        >{{ mousePosition }} </span
      >м ниже уровня моря
    </span>
  </div>

  <div id="backGroundLayoutDiv" @click="showClickPosition">
    <div
      :id="overgroundLayout.name + 'Div'"
      :name="overgroundLayout.name"
      :class="['backgroundLayout', overgroundLayout.name]"
      :fromHeight="overgroundLayout.fromHeight"
      :toHeight="overgroundLayout.toHeight"
      :height="overgroundLayout.height"
      :heightPx="overgroundLayout.heightPx"></div>
    <div
      :id="zeroLayout.name + 'Div'"
      :name="zeroLayout.name"
      :class="['backgroundLayout', zeroLayout.name]"
      :fromHeight="zeroLayout.fromHeight"
      :toHeight="zeroLayout.toHeight"
      :height="zeroLayout.height"
      :heightPx="zeroLayout.heightPx"></div>
    <div
      :id="undergroundLayout.name + 'Div'"
      :name="undergroundLayout.name"
      :class="['backgroundLayout', undergroundLayout.name]"
      :fromHeight="undergroundLayout.fromHeight"
      :toHeight="undergroundLayout.toHeight"
      :height="undergroundLayout.height"
      :heightPx="undergroundLayout.heightPx"></div>
  </div>
</template>

<script>
  export default {
    name: 'mainPage',
    data() {
      return {
        currentLayout: 'zeroLayout',
        overgroundLayout: {
          name: 'overgroundLayout',
          fromHeight: 0,
          toHeight: 358000,
          height: 358000,
          heightPx: '358000px',
        },
        zeroLayout: {
          name: 'zeroLayout',
          fromHeight: 0,
          toHeight: 0,
          height: 5,
          heightPx: '5px',
        },
        undergroundLayout: {
          name: 'undergroundLayout',
          fromHeight: 0,
          toHeight: -63570,
          height: 63570,
          heightPx: '63570px',
        },
        totalHeight: 421570,
        mousePosition: 0,
      };
    },
    methods: {
      showClickPosition(event) {
        let currentClickPosition = event.offsetY;
        this.currentLayout = event.target.getAttribute('name');

        if (currentClickPosition === 0 || this.currentLayout === this.zeroLayout.name)
          this.mousePosition = 0;
        else if (this.currentLayout === this.overgroundLayout.name)
          this.mousePosition = Number(event.target.getAttribute('toHeight')) - currentClickPosition;
        else if (this.currentLayout === this.undergroundLayout.name)
          this.mousePosition = currentClickPosition;
      },
    },
  };
</script>

<style>
  .heightMeter {
    text-align: center;
    font-size: x-large;
    font-weight: bold;
    padding-bottom: 3%;
  }

  .heightMeterNumber {
    font-size: xx-large;
  }

  .overgroundLayout {
    height: v-bind('overgroundLayout.heightPx');
    background-color: rgb(207, 222, 231);
  }

  .zeroLayout {
    height: v-bind('zeroLayout.heightPx');
    background-color: rgb(189, 176, 163);
  }

  .undergroundLayout {
    height: v-bind('undergroundLayout.heightPx');
    background-color: rgb(247, 235, 222);
  }

  .backgroundLayout {
    z-index: 1;
  }
</style>
