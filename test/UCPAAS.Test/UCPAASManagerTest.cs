﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UCPAAS.Internal;
using Xunit;

namespace UCPAAS.Test {
    public class UCPAASManagerTest {
        [Fact]
        public async Task CreateAccount() {
            var manger = new UCPAASManager(new DataProvider());
            var rlt = await manger.ApplyClientAsync("Apply", new Model.ApplyUCPAAS {
                client = new Model.Apply {
                    mobile = "18679236954",
                    clientType = "0",
                    charge = "0",
                    friendlyName = string.Empty
                }
            });
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(rlt));
            Assert.True(true);
        }

        [Fact]
        public async Task FindAccount() {
            var manger = new UCPAASManager(new DataProvider());
            var rlt = await manger.ClientDetailAsync("FindClient", "18679236954");
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(rlt));
            Assert.True(rlt.resp.IsSucceedCode);
        }

        [Fact]
        public async Task CallBack() {
            var manger = new UCPAASManager(new DataProvider());
            var rlt = await manger.CallBackAsync("CallBack", new Model.CallBackUCPAAS {
                callback = new Model.CallBack {
                    fromClient = "65168073890888",
                    fromSerNum = "057156103642",
                    to = "13783783183",
                    toSerNum = "057156103642",
                    maxallowtime = 3600,
                    userData = "cs123",
                    ringtoneID= "1753"
                }
            });
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(rlt));
            Assert.True(true);
        }
    }
}
