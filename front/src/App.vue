<template>
  <div
    id="overgroundHeightMeterDiv"
    class="fixed-bottom heightMeter"
    v-if="currentLayout.parentLayoutName === overgroundLayout.name">
    <span>
      <span id="overgroundHeightMeterNumberDiv" class="heightMeterNumber">
        {{ mousePosition }}
      </span>
      км над уровнем моря
    </span>
  </div>
  <div
    id="zeroHeightMeterDiv"
    class="fixed-bottom heightMeter"
    v-else-if="currentLayout.name === zeroLayout.name">
    <span id="zeroHeightMeterNumberSpan" class="heightMeterNumber">нулевой уровень</span>
  </div>
  <div
    id="undergroundHeightMeterDiv"
    class="fixed-bottom heightMeter"
    v-else-if="currentLayout.parentLayoutName === undergroundLayout.name">
    <span>
      на
      <span id="undergroundHeightMeterNumberSpan" class="heightMeterNumber">
        {{ mousePosition }}
      </span>
      км ниже уровня моря
    </span>
  </div>

  <div id="backGroundLayoutDiv" @click="showClickPosition">
    <div
      :id="overgroundLayout.name + 'Div'"
      :number="overgroundLayout.layoutNumber"
      :name="overgroundLayout.name"
      :class="overgroundLayout.name"
      :fromHeight="overgroundLayout.fromHeight"
      :toHeight="overgroundLayout.toHeight"
      :height="overgroundLayout.height"
      :heightPx="overgroundLayout.heightPx">
      <div
        :id="overgroundLayout.troposphere.name + 'Div'"
        :number="overgroundLayout.troposphere.layoutNumber"
        :name="overgroundLayout.troposphere.name"
        :rusName="overgroundLayout.troposphere.rusName"
        :class="overgroundLayout.troposphere.name"
        :fromHeight="overgroundLayout.troposphere.fromHeight"
        :toHeight="overgroundLayout.troposphere.toHeight"
        :height="overgroundLayout.troposphere.height"
        :heightPx="overgroundLayout.troposphere.heightPx"></div>
    </div>
    <div
      :id="zeroLayout.name + 'Div'"
      :name="zeroLayout.name"
      :ref="zeroLayout.name"
      :class="zeroLayout.name"
      :fromHeight="zeroLayout.fromHeight"
      :toHeight="zeroLayout.toHeight"
      :height="zeroLayout.height"
      :heightPx="zeroLayout.heightPx"></div>
    <div
      :id="undergroundLayout.name + 'Div'"
      :number="undergroundLayout.layoutNumber"
      :name="undergroundLayout.name"
      :class="undergroundLayout.name"
      :fromHeight="undergroundLayout.fromHeight"
      :toHeight="undergroundLayout.toHeight"
      :height="undergroundLayout.height"
      :heightPx="undergroundLayout.heightPx">
      <div
        :id="undergroundLayout.continentalCrust.name + 'Div'"
        :number="undergroundLayout.continentalCrust.layoutNumber"
        :name="undergroundLayout.continentalCrust.name"
        :rusName="undergroundLayout.continentalCrust.rusName"
        :class="undergroundLayout.continentalCrust.name"
        :fromHeight="undergroundLayout.continentalCrust.fromHeight"
        :toHeight="undergroundLayout.continentalCrust.toHeight"
        :height="undergroundLayout.continentalCrust.height"
        :heightPx="undergroundLayout.continentalCrust.heightPx"></div>
      <div
        :id="undergroundLayout.lithosphere.name + 'Div'"
        :number="undergroundLayout.lithosphere.layoutNumber"
        :name="undergroundLayout.lithosphere.name"
        :rusName="undergroundLayout.continentalCrust.rusName"
        :class="undergroundLayout.lithosphere.name"
        :fromHeight="undergroundLayout.lithosphere.fromHeight"
        :toHeight="undergroundLayout.lithosphere.toHeight"
        :height="undergroundLayout.lithosphere.height"
        :heightPx="undergroundLayout.lithosphere.heightPx"></div>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'mainPage',
    data() {
      return {
        currentLayout: {
          name: 'zeroLayout',
          rusName: '',
          number: 0,
          fromHeight: 0,
          toHeight: 0,
          height: 0,
          heightPx: '',
          parentLayoutName: '',
        },
        overgroundLayout: {
          name: 'overgroundLayout',
          number: 0,
          fromHeight: 0,
          toHeight: 35800,
          height: 35800,
          heightPx: '35800px',
          troposphere: {
            name: 'troposphere',
            rusName: 'Тропосфера',
            number: 1,
            fromHeight: 0,
            toHeight: 10,
            height: 10,
            heightPx: '10px',
          },
        },
        zeroLayout: {
          name: 'zeroLayout',
          fromHeight: 0,
          toHeight: 0,
          height: 2,
          heightPx: '2px',
        },
        undergroundLayout: {
          name: 'undergroundLayout',
          number: 0,
          fromHeight: 0,
          toHeight: -6371,
          height: 6371,
          heightPx: '6371px',
          continentalCrust: {
            name: 'continentalCrust',
            rusName: 'Континентальная кора',
            number: 1,
            fromHeight: 0,
            toHeight: -35,
            height: 35,
            heightPx: '35px',
          },
          lithosphere: {
            name: 'lithosphere',
            rusName: 'Литосфера',
            number: 2,
            fromHeight: -35,
            toHeight: -60,
            height: 25,
            heightPx: '25px',
          },
        },
        totalHeight: 42171,
        mousePosition: 0,
      };
    },
    methods: {
      showClickPosition(event) {
        let currentClickPosition = event.offsetY;
        let currentElement = event.target;
        this.currentLayout = {
          name: currentElement.getAttribute('name'),
          rusName: currentElement.getAttribute('rusName'),
          number: Number(currentElement.getAttribute('number')),
          fromHeight: Number(currentElement.getAttribute('fromHeight')),
          toHeight: Number(currentElement.getAttribute('toHeight')),
          height: Number(currentElement.getAttribute('height')),
          heightPx: currentElement.getAttribute('heightPx'),
          parentLayoutName: currentElement.parentElement.getAttribute('name'),
        };

        if (this.currentLayout.parentLayoutName === this.overgroundLayout.name) {
          this.mousePosition = this.currentLayout.toHeight - currentClickPosition;
        } else if (this.currentLayout.parentLayoutName === this.undergroundLayout.name) {
          this.mousePosition = Math.abs(this.currentLayout.fromHeight - currentClickPosition);
        }
      },
      scrollToZeroLayout() {
        this.$refs.zeroLayout?.scrollIntoView({ block: 'center' });
      },
    },
    mounted() {
      this.scrollToZeroLayout();
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
    background-color: rgb(1, 18, 29);
    display: flex;
    flex-direction: column-reverse;
  }
  .troposphere {
    height: v-bind('overgroundLayout.troposphere.heightPx');
    background-color: rgb(221, 233, 240);
  }

  .zeroLayout {
    height: v-bind('zeroLayout.heightPx');
    background-color: rgb(131, 212, 176);
  }

  .undergroundLayout {
    height: v-bind('undergroundLayout.heightPx');
    background-color: rgb(36, 19, 1);
  }
  .continentalCrust {
    height: v-bind('undergroundLayout.continentalCrust.heightPx');
    background-color: rgb(247, 235, 222);
  }
  .lithosphere {
    height: v-bind('undergroundLayout.lithosphere.heightPx');
    background-color: rgb(230, 213, 195);
  }
</style>
