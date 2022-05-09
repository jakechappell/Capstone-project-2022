<template>
    <div id="workflows-page">
        <div class="text-center m-2" style="margin: 10px">
            <h4><span class="info-box bg-accuBlue">This page shows common workflows/tutorials on using the Cheetah API and it's endpoints</span></h4>
        </div>

        <div class="row text-center">
            <div class="col-md">
                <div class="workflow-container row" v-for="(workflow, index) in workflowsCol1" v-bind:key="index">
                    <h5 @click="toggle_icon(workflow.accordKey)"
                        v-b-toggle="'workflowsAccord-' + workflow.accordKey" class="workflow">{{ workflow.name }}
                        <b-icon
                            icon="chevron-right"
                            aria-hidden="true"
                            class="float-right mt-1"
                        ></b-icon>
                        <i class="fas fa-caret-down"></i>
                    </h5>
                    <b-collapse :id="'workflowsAccord-' + workflow.accordKey" accordian="workflowsAccord" 
                    role="tabpanel" class="mt-3 ml-2">
                        <div class="tutorial" v-html="workflow.content"></div>
                    </b-collapse>
                </div>
            </div>

            <div class="col-md">
                <div class="workflow-container row" v-for="(workflow, index) in workflowsCol2" v-bind:key="index">
                    <h5 v-if="workflow"
                        @click="toggle_icon(workflow.accordKey)"
                        v-b-toggle="'workflowsAccord-' + workflow.accordKey" class="workflow">{{ workflow.name }}
                        <b-icon
                            icon="chevron-right"
                            aria-hidden="true"
                            class="float-right mt-1"
                        ></b-icon>
                        <i class="fas fa-caret-down"></i>
                    </h5>
                    <b-collapse v-if="workflow" :id="'workflowsAccord-' + workflow.accordKey" accordian="workflowsAccord" 
                    role="tabpanel" class="mt-3 ml-2">
                        <div class="tutorial" v-html="workflow.content"></div>
                    </b-collapse>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import Workflows from "../assets/workflows.json";

    export default {
        data() {
            return {
                workflows: Workflows.workflows,
                workflowsCol1: [],
                workflowsCol2: []
            }
        },
        created() {
            for (let i = 0; i < this.workflows.length; i++) {
                if (i % 2 == 0)
                    this.workflowsCol1.push(this.workflows[i]);
                else
                    this.workflowsCol2.push(this.workflows[i]);
            }
        },
    }
</script>

<style lang="less" scoped>
    .info-box {
        color: white;
        border: solid black 2px;
        border-radius: 10px;
        padding: 5px;
    }

    .workflow-container {
        margin: 1rem 1rem 1rem 1rem;
    }
    .workflow {
        border-bottom: 5px double rgba(39, 39, 39, 0.845);
        padding: 0.25rem;
        box-shadow: -3px -4px 8px 0 rgba(0, 0, 0, 0.2);
    }
    .tutorial {
        text-align: left;
        padding: 5px;
        box-shadow: 0 4px 8px 0 rgba(0, 0, 0, 0.2), 0 6px 20px 0 rgba(0, 0, 0, 0.19);
    }
</style>