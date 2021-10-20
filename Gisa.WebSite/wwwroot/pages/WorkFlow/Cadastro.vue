<template>
    <div id="drawflow"></div>
</template>
<script>
    import Drawflow from 'drawflow'
    import styleDrawflow from 'drawflow/dist/drawflow.min.css'


    export default {
        name: 'App',
        data: function () {
            return {
                nodes: [
                    { id: 1, x: 140, y: 270, name: 'Start', type: 'start' },
                    { id: 2, x: 540, y: 270, name: 'End', type: 'end' },
                ],
                connections: [
                    {
                        source: { id: 1, position: 'right' },
                        destination: { id: 2, position: 'left' },
                        id: 1,
                        type: 'pass',
                    },
                ],
            };
        },
        methods: {
            handleChartSave(nodes, connections) {
            },
            handleEditNode(node) {
            },
            handleEditConnection(connection) {
            },
        }
    };
</script>