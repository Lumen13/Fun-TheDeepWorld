<template>
  <LayoutModal
    v-if="layoutModal.isVisible"
    :header="layoutModal.header"
    :body="layoutModal.body"
    :footer="layoutModal.footer" />

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
        v-for="l in overgroundLayout.subLayouts"
        :key="l.number"
        :id="l.name + 'Div'"
        :number="l.layoutNumber"
        :name="l.name"
        :rusName="l.rusName"
        :class="['layout', l.name]"
        :fromHeight="l.fromHeight"
        :toHeight="l.toHeight"
        :height="l.height"
        :heightPx="l.heightPx">
        {{ l.rusName }}
      </div>
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
        v-for="l in undergroundLayout.subLayouts"
        :key="l.number"
        :id="l.name + 'Div'"
        :number="l.layoutNumber"
        :name="l.name"
        :rusName="l.rusName"
        :class="['layout', l.name]"
        :fromHeight="l.fromHeight"
        :toHeight="l.toHeight"
        :height="l.height"
        :heightPx="l.heightPx"
        @click="undergroundLayoutClick">
        {{ l.rusName }}
      </div>
    </div>
  </div>
</template>

<script>
  import LayoutModal from '@/components/layouts/LayoutModal';

  export default {
    name: 'mainPage',
    components: { LayoutModal },
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
          subLayouts: [
            {
              name: 'troposphere',
              rusName: 'Тропосфера',
              number: 1,
              fromHeight: 0,
              toHeight: 15,
              height: 15,
              heightPx: '15px',
            },
            {
              name: 'stratosphere',
              rusName: 'Стратосфера',
              number: 2,
              fromHeight: 15,
              toHeight: 50,
              height: 35,
              heightPx: '35px',
            },
            {
              name: 'mesosphere',
              rusName: 'Мезосфера',
              number: 3,
              fromHeight: 50,
              toHeight: 80,
              height: 30,
              heightPx: '30px',
            },
            {
              name: 'thermosphere',
              rusName: 'Термосфера',
              number: 4,
              fromHeight: 80,
              toHeight: 700,
              height: 620,
              heightPx: '620px',
            },
            {
              name: 'exosphere',
              rusName: 'Экзосфера',
              number: 5,
              fromHeight: 700,
              toHeight: 10000,
              height: 9300,
              heightPx: '9300px',
            },
            {
              name: 'space',
              rusName: 'Космическое пространство',
              number: 6,
              fromHeight: 10000,
              toHeight: 35800,
              height: 25800,
              heightPx: '25800px',
            },
          ],
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
          subLayouts: [
            {
              name: 'continentalCrust',
              rusName: 'Континентальная кора',
              number: 1,
              fromHeight: 0,
              toHeight: -35,
              height: 35,
              heightPx: '35px',
            },
            {
              name: 'lithosphere',
              rusName: 'Литосфера',
              number: 2,
              fromHeight: -35,
              toHeight: -60,
              height: 25,
              heightPx: '25px',
            },
            {
              name: 'upperMantle',
              rusName: 'Верхняя мезосфера (верхняя мантия)',
              number: 3,
              fromHeight: -60,
              toHeight: -100,
              height: 40,
              heightPx: '40px',
            },
            {
              name: 'asthenosphere',
              rusName: 'Астеносфера',
              number: 4,
              fromHeight: -100,
              toHeight: -200,
              height: 100,
              heightPx: '100px',
            },
            {
              name: 'mantle',
              rusName: 'Мантия',
              number: 5,
              fromHeight: -200,
              toHeight: -660,
              height: 460,
              heightPx: '460px',
            },
            {
              name: 'lowerMantle',
              rusName: 'Нижняя мезосфера (нижняя мантия)',
              number: 6,
              fromHeight: -660,
              toHeight: -2890,
              height: 2230,
              heightPx: '2230px',
            },
            {
              name: 'outerCore',
              rusName: 'Внешнее ядро',
              number: 7,
              fromHeight: -2890,
              toHeight: -5150,
              height: 2260,
              heightPx: '2260px',
            },
            {
              name: 'innerCore',
              rusName: 'Внутреннее Ядро',
              number: 8,
              fromHeight: -5150,
              toHeight: -6371,
              height: 1221,
              heightPx: '1221px',
            },
          ],
        },
        totalHeight: 42171,
        mousePosition: 0,
        layoutModal: {
          isVisible: false,
          header: 'test',
          body: 'test',
          footer: 'test',
        },
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
          this.mousePosition = Math.abs(this.currentLayout.toHeight - currentClickPosition);
        } else if (this.currentLayout.parentLayoutName === this.undergroundLayout.name) {
          this.mousePosition = Math.abs(this.currentLayout.fromHeight - currentClickPosition);
        }
      },
      scrollToZeroLayout() {
        this.$refs.zeroLayout?.scrollIntoView({ block: 'center' });
      },
      undergroundLayoutClick(event) {
        let attributes = event.target.attributes;

        this.layoutModal.header = attributes.rusName.value;
        this.layoutModal.body = `основной текст о ${attributes.name.value}`;
        this.layoutModal.footer = `вторичный текст о ${attributes.name.value}`;
        this.layoutModal.isVisible = true;
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
    -webkit-text-stroke: 0.7px rgb(39, 39, 39);
  }
  .heightMeterNumber {
    font-size: xx-large;
  }

  #backGroundLayoutDiv {
    text-align: center;
  }
  .layout {
    color: dimgray;
    font-family: cursive;
    font-weight: bold;
    font-size: large;
    display: flex;
    justify-content: center;
    align-content: center;
    flex-direction: column;
  }

  .overgroundLayout {
    height: v-bind('overgroundLayout.heightPx');
    background-color: rgb(1, 18, 29);
    display: flex;
    flex-direction: column-reverse;
  }
  .troposphere {
    height: v-bind('overgroundLayout.subLayouts[0].heightPx');
    background-color: rgb(221, 233, 240);
    font-size: 12px;
    color: rgb(10, 58, 4);
  }
  .stratosphere {
    height: v-bind('overgroundLayout.subLayouts[1].heightPx');
    background-color: rgb(182, 207, 221);
    color: rgb(51, 92, 46);
  }
  .mesosphere {
    height: v-bind('overgroundLayout.subLayouts[2].heightPx');
    background-color: rgb(136, 178, 202);
    color: rgb(25, 156, 10);
  }
  .thermosphere {
    height: v-bind('overgroundLayout.subLayouts[3].heightPx');
    background-color: rgb(81, 140, 173);
    color: rgb(71, 192, 55);
  }
  .exosphere {
    height: v-bind('overgroundLayout.subLayouts[4].heightPx');
    background-color: rgb(42, 105, 141);
    color: rgb(79, 214, 61);
  }
  .space {
    height: v-bind('overgroundLayout.subLayouts[5].heightPx');
    background-color: rgb(1, 18, 29);
    color: rgb(96, 255, 75);
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
    height: v-bind('undergroundLayout.subLayouts[0].heightPx');
    background-image: linear-gradient(to right, rgba(247, 235, 222, 0.8) 0 100%),
      url('images/continentalCrust.png');
    color: rgb(122, 62, 45);
  }
  .lithosphere {
    height: v-bind('undergroundLayout.subLayouts[1].heightPx');
    background-image: linear-gradient(to right, rgba(230, 213, 195, 0.8) 0 100%),
      url('images/lithosphere.png');
    color: rgb(128, 52, 31);
  }
  .upperMantle {
    height: v-bind('undergroundLayout.subLayouts[2].heightPx');
    background-image: linear-gradient(to right, rgba(207, 185, 162, 0.8) 0 100%),
      url('images/upperMantle.png');
    color: rgb(90, 37, 23);
  }
  .asthenosphere {
    height: v-bind('undergroundLayout.subLayouts[3].heightPx');
    background-image: linear-gradient(to right, rgba(187, 162, 136, 0.9) 0 100%),
      url('images/asthenosphere.png');
    color: rgb(48, 17, 8);
  }
  .mantle {
    height: v-bind('undergroundLayout.subLayouts[4].heightPx');
    background-image: linear-gradient(to right, rgba(156, 132, 81, 0.8) 0 100%),
      url('images/mantle.png');
    color: black;
  }
  .lowerMantle {
    height: v-bind('undergroundLayout.subLayouts[5].heightPx');
    background-image: linear-gradient(to right, rgba(151, 114, 44, 0.8) 0 100%),
      url('images/lowerMantle.png');
    color: wheat;
  }
  .outerCore {
    height: v-bind('undergroundLayout.subLayouts[6].heightPx');
    background-color: rgb(204, 103, 55);
    color: wheat;
  }
  .innerCore {
    height: v-bind('undergroundLayout.subLayouts[7].heightPx');
    background-color: rgb(202, 70, 70);
    color: wheat;
  }
</style>
