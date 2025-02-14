/*
 * Modified MIT License
 *
 * Copyright 2023 OneSignal
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * 1. The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * 2. All copies of substantial portions of the Software may only be used in connection
 * with services provided by OneSignal.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System.Collections.Generic;
using System.Threading.Tasks;
using OneSignalSDK.Notifications;
using OneSignalSDK.InAppMessages;
using OneSignalSDK.Debug;
using OneSignalSDK.Debug.Utilities;
using OneSignalSDK.Location;
using OneSignalSDK.Session;
using OneSignalSDK.User;
using OneSignalSDK.LiveActivities;

namespace OneSignalSDK {
    /// <summary>
    /// Implementationless variation of the OneSignal SDK so that it "runs" in the Editor
    /// </summary>
    internal sealed class OneSignalNative : OneSignalPlatform {
        private UserManager _user = new UserManager();
        private SessionManager _session = new SessionManager();
        private NotificationsManager _notifications = new NotificationsManager();
        private LocationManager _location = new LocationManager();
        private InAppMessagesManager _inAppMessages = new InAppMessagesManager();
        private DebugManager _debug = new DebugManager();
        private LiveActivitiesManager _liveActivities = new LiveActivitiesManager();
        private bool _consentGiven;
        private bool _consentRequired;

        public override IUserManager User {
            get => _user;
        }
        
        public override ISessionManager Session {
            get => _session;
        }
        
        public override INotificationsManager Notifications {
            get => _notifications;
        }
        
        public override ILocationManager Location {
            get => _location;
        }

        public override IInAppMessagesManager InAppMessages {
            get => _inAppMessages;
        }

        public override IDebugManager Debug {
            get => _debug;
        }

        public override ILiveActivitiesManager LiveActivities {
            get => _liveActivities;
        }

        public override bool ConsentGiven {
            set => _consentGiven = value;
        }

        public override bool ConsentRequired {
            set => _consentRequired = value;
        }

        public override void Initialize(string appId) {
            if (string.IsNullOrEmpty(appId)) {
                SDKDebug.Error("appId is null or empty");
                return;
            }

            _init(appId);

            SDKDebug.Warn("Native SDK is a placeholder. Please run on supported platform (iOS or Android).");
        }

        public override void Login(string externalId, string jwtBearerToken = null) {

        }

        public override void Logout() {

        }
    }
}