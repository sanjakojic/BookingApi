﻿#region Copyright Vanderlande Industries B.V. 2022

// Copyright (c) 2022 Vanderlande Industries.
// All rights reserved.
// 
// The copyright to the computer program(s) herein is the property of
// Vanderlande Industries. The program(s) may be used and/or copied
// only with the written permission of the owner or in accordance with
// the terms and conditions stipulated in the contract under which the
// program(s) have been supplied.

#endregion

namespace BookingApi.Request;

    public class GetServiceRequest
    {
        public string? ServiceName { get; set; }
        public GeoLocation? GeoLocation { get; set; }
    }