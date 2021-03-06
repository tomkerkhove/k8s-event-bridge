﻿using Kubernetes.EventGrid.Bridge.Contracts.Enums;
using Kubernetes.EventGrid.Core.Kubernetes;
using Kubernetes.EventGrid.Tests.Unit.Events;
using Xunit;

namespace Kubernetes.EventGrid.Tests.Unit.Kubernetes
{
    [Trait("Category", "Unit")]
    public class KubernetesEventParserUnitTests
    {
        [Fact]
        public void ParseFromRawNativeEvent_ParseRawEvent_ReturnsRawEvent()
        {
            // Arrange
            var kubernetesEventParser = new KubernetesEventParser();
            var rawKubernetesEvent = KubernetesEventSamples.GetRawContainerStartedEvent();

            // Act
            var kubernetesEvent = kubernetesEventParser.ParseFromRawNativeEvent(rawKubernetesEvent);

            // Assert
            Assert.NotNull(kubernetesEvent);
            Assert.Equal(KubernetesEventType.Raw, kubernetesEvent.Type);
            Assert.NotNull(kubernetesEvent.Payload);
        }

        [Fact]
        public void ParseFromRawNativeEvent_ParseRawClusterAutoscalerScaleInEvent_ReturnsClusterAutoscalerScaleInEvent()
        {
            // Arrange
            var kubernetesEventParser = new KubernetesEventParser();
            var rawClusterAutoscalerScaleDownEvent = KubernetesEventSamples.GetRawClusterAutoscalerScaleDownEvent();

            // Act
            var kubernetesEvent = kubernetesEventParser.ParseFromRawNativeEvent(rawClusterAutoscalerScaleDownEvent);

            // Assert
            Assert.NotNull(kubernetesEvent);
            Assert.Equal(KubernetesEventType.ClusterAutoscalerScaleIn, kubernetesEvent.Type);
            Assert.NotNull(kubernetesEvent.Payload);
        }
    }
}
