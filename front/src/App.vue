<template>
  <div id="positiveHeightMeter" class="heightMeter" v-if="isCurrentLayoutHasPositiveValue">
    <span>
      <span id="heightMeterNumber">{{ mousePosition }} </span>м над уровнем моря
    </span>
  </div>
  <div id="negativeHeightMeter" class="heightMeter" v-else>
    <span>
      на <span id="heightMeterNumber">{{ mousePosition }} </span>м ниже уровня моря
    </span>
  </div>

  <div
    id="overgroundLayoutId"
    class="backgroundLayout, overgroundLayout"
    :hasPositiveValue="true"
    :fromHeight="overgroundLayout.fromHeight"
    :toHeight="overgroundLayout.toHeight"
    :height="overgroundLayout.height"
    @click="showOvergroundMousePosition"></div>
  <div
    id="undergroundLayoutId"
    class="backgroundLayout, undergroundLayout"
    :hasPositiveValue="false"
    :fromHeight="undergroundLayout.fromHeight"
    :toHeight="undergroundLayout.toHeight"
    :height="undergroundLayout.height"
    @click="showUndergroundPosition"></div>
</template>

<script>
  export default {
    name: 'mainPage',
    data() {
      return {
        isCurrentLayoutHasPositiveValue: true,
        overgroundLayout: {
          fromHeight: 0,
          toHeight: 358000,
          height: 358000,
          heightPx: '358000px',
        },
        undergroundLayout: {
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
      showOvergroundMousePosition(event) {
        this.setPositiveValueFlagByEvent(event);

        let layerMousePosition = event.offsetY;
        let layerElementToHeight = Number(event.target.getAttribute('toHeight'));
        this.mousePosition = layerElementToHeight - layerMousePosition;
      },
      showUndergroundPosition(event) {
        this.setPositiveValueFlagByEvent(event);

        this.mousePosition = event.offsetY;
      },
      setPositiveValueFlagByEvent(event) {
        this.isCurrentLayoutHasPositiveValue =
          'true' === event.target.getAttribute('hasPositiveValue');
      },
    },
  };
</script>

<style>
  .heightMeter {
    position: fixed;
    margin-top: 20%;
    top: 50%;
    left: 15%;
    right: 15%;
    text-align: center;
    font-size: x-large;
    font-weight: bold;
    opacity: 80%;
    z-index: 100;
  }

  #heightMeterNumber {
    font-size: xx-large;
  }

  .overgroundLayout {
    height: v-bind('overgroundLayout.heightPx');
    background-color: rgb(207, 222, 231);
  }

  .undergroundLayout {
    height: v-bind('undergroundLayout.heightPx');
    background-color: rgb(247, 235, 222);
  }

  .backgroundLayout {
    position: absolute;
    width: 100%;
    z-index: 1;
  }
</style>
