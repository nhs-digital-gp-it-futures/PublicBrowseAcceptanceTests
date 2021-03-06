﻿namespace NHSDPublicBrowseAcceptanceTests.TestData.Solutions
{
    using System.Collections.Generic;

    internal static class ClientApplicationStrings
    {
        internal const string BrowserBasedComplete =
            "\"BrowsersSupported\":[\"Google Chrome\"],\"MobileResponsive\":true,\"Plugins\":{\"Required\":false,\"AdditionalInformation\":\"Plugins additional info\"},\"MinimumConnectionSpeed\":\"1Mbps\",\"MinimumDesktopResolution\":\"21:9-2560 x 1080\",\"HardwareRequirements\":\"Hardware Requirements\",\"AdditionalInformation\":\"Additional Information\",\"MobileFirstDesign\":true";

        internal const string NativeMobileComplete =
            "\"NativeMobileHardwareRequirements\":\"Hardware Requirements\",\"NativeMobileFirstDesign\":true,\"MobileOperatingSystems\":{\"OperatingSystems\":[\"Apple IOS\",\"Android\"],\"OperatingSystemsDescription\":\"Operating System Description\"},\"MobileConnectionDetails\":{\"MinimumConnectionSpeed\":\"1Mbps\",\"ConnectionType\":[\"GPRS\",\"3G\",\"4G\",\"5G\",\"Wifi\"],\"Description\":\"Connection Details Description\"},\"MobileMemoryAndStorage\":{\"MinimumMemoryRequirement\":\"256MB\",\"Description\":\"Additional Storage Requirements\"},\"MobileThirdParty\":{\"ThirdPartyComponents\":\"Components Description\",\"DeviceCapabilities\":\"Device Capabilities Description\"},\"NativeMobileAdditionalInformation\":\"Additional Information\"";

        internal const string NativeDesktopComplete =
            "\"NativeDesktopHardwareRequirements\":\"Hardware requirements\",\"NativeDesktopOperatingSystemsDescription\":\"Windows 7,8,10\r\nUbuntu\",\"NativeDesktopMinimumConnectionSpeed\":\"0.5Mbps\",\"NativeDesktopThirdParty\":{\"ThirdPartyComponents\":\"Third party\",\"DeviceCapabilities\":\"Device Capabilities\"},\"NativeDesktopMemoryAndStorage\":{\"MinimumMemoryRequirement\":\"256MB\",\"StorageRequirementsDescription\":\"approximately 10MB, plus additional for cache\",\"MinimumCpu\":\"0.98hz\",\"RecommendedResolution\":\"16:9 - 640 x 360\"},\"NativeDesktopAdditionalInformation\":\"Additional Information\"";

        internal static Dictionary<string, string> BrowserSections = new() { { "Browsers supported", "\"BrowsersSupported\":[\"Google Chrome\"],\"MobileResponsive\":true," }, { "Plug-ins or extensions", "\"Plugins\":{\"Required\":false,\"AdditionalInformation\":\"Plugins additional info\"}," }, { "Connectivity and resolution", "\"MinimumConnectionSpeed\":\"1Mbps\",\"MinimumDesktopResolution\":\"21:9-2560 x 1080\"," }, { "Mobile first", "\"MobileFirstDesign\":true" }, { "Hardware requirements", "\"HardwareRequirements\":\"Hardware Requirements\"," }, { "Additional information", "\"AdditionalInformation\":\"Additional Information\"," } };

        internal static Dictionary<string, string> NativeMobileSections = new() { { "Mobile first", "\"NativeMobileFirstDesign\":true," }, { "Supported operating systems", "\"MobileOperatingSystems\":{\"OperatingSystems\":[\"Apple IOS\",\"Android\"],\"OperatingSystemsDescription\":\"Operating System Description\"}," }, { "Memory and storage", "\"MobileMemoryAndStorage\":{\"MinimumMemoryRequirement\":\"256MB\",\"Description\":\"Additional Storage Requirements\"}," }, { "Hardware requirements", "\"NativeMobileHardwareRequirements\":\"Hardware Requirements\"," }, { "Additional information", "\"NativeMobileAdditionalInformation\":\"Additional Information\"}" }, { "Connection details", "\"MobileConnectionDetails\":{\"MinimumConnectionSpeed\":\"1Mbps\",\"ConnectionType\":[\"GPRS\",\"3G\",\"4G\",\"5G\",\"Wifi\"],\"Description\":\"Connection Details Description\"}," } };

        internal static Dictionary<string, string> NativeDesktopSections = new() { { "Supported operating systems", "\"NativeDesktopOperatingSystemsDescription\":\"Windows 7,8,10\r\nUbuntu\"," }, { "Connection details", "\"NativeDesktopMinimumConnectionSpeed\":\"0.5Mbps\"," }, { "Memory, storage, processing and aspect ratio", "\"NativeDesktopMemoryAndStorage\":{\"MinimumMemoryRequirement\":\"256MB\",\"StorageRequirementsDescription\":\"approximately 10MB, plus additional for cache\",\"MinimumCpu\":\"0.98hz\",\"RecommendedResolution\":\"16:9 - 640 x 360\"}," } };
    }
}
